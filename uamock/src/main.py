import logging
import asyncio
import sys
from asyncua import Server, ua

sys.path.insert(0, "..")


async def main():
    _logger = logging.getLogger('asyncua')
    # setup our server
    server = Server()
    await server.init()
    server.set_endpoint('opc.tcp://0.0.0.0:4840')

    # setup our own namespace, not really necessary but should as spec
    uri = 'http://test.brewcontroller.server'
    idx = await server.register_namespace(uri)

    # populating our address space
    # server.nodes, contains links to very common nodes like objects and root
    root_obj = await server.nodes.objects.add_object(idx, 'Controllers')
    t1_toggler = await root_obj.add_variable(idx, 'T1_Toggler', False, ua.VariantType.Boolean)
    t1_wanted = await root_obj.add_variable(idx, 'T1_Wanted', 0.0, ua.VariantType.Double)
    await root_obj.add_variable(idx, 'T1_Current', 0.0, ua.VariantType.Double)

    # await t1_toggler.set_writable()
    await t1_wanted.set_writable()

    _logger.info('Starting server!')
    async with server:
        while True:
            await asyncio.sleep(1)
            new_val = await t1_wanted.get_value() + 0.1
            _logger.info('Set value of %s to %.1f', t1_wanted, new_val)
            await t1_wanted.write_value(new_val)


if __name__ == '__main__':
    logging.basicConfig(level=logging.DEBUG)

    asyncio.run(main(), debug=True)
