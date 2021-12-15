import { createClient, defaultExchanges, subscriptionExchange } from '@urql/svelte'

import { SubscriptionClient } from 'subscriptions-transport-ws'
import { devtoolsExchange } from '@urql/devtools'

const graphqlHostname = process.env.NODE_ENV !== 'development' ? window.location.host : 'localhost:5000'
const [http, ws] = window.location.protocol.endsWith('s:') ? ['https', 'wss'] : ['http', 'ws']

const wsClient = new SubscriptionClient(`${ws}://${graphqlHostname}/graphql`, {
  reconnect: true,
})

let exchanges = [
  subscriptionExchange({
    forwardSubscription: (operation) => wsClient.request(operation),
  }),
  ...defaultExchanges,
]

if (process.env.NODE_ENV === 'development') {
  console.log('dev mode active')
  exchanges = [
    devtoolsExchange,
    ...exchanges,
  ]
}

const client = createClient({
  url: `${http}://${graphqlHostname}/graphql`,
  exchanges,
})

export default client
