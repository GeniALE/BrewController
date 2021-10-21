<script lang="ts">
  import Drawer, { Content } from '@smui/drawer'
  import List, { Item, Text } from '@smui/list'
  import { useLocation, useNavigate } from 'svelte-navigator'

  const location = useLocation()
  const navigate = useNavigate()

  const goto = (location: string) => () => navigate(location)
</script>

<Drawer>
  <Content>
    <List>
      <Item on:click={goto('/')} activated={$location.pathname === '/'}>
        <Text>Overview</Text>
      </Item>
      <Item on:click={goto('/logs')} activated={$location.pathname === '/logs'}>
        <Text>Logs</Text>
      </Item>
      <Item on:click={goto('/charts')} activated={$location.pathname === '/charts'}>
        <Text>Charts</Text>
      </Item>
      <Item on:click={goto('/settings')} activated={$location.pathname === '/settings'}>
        <Text>Settings</Text>
      </Item>
      {#if $location.pathname.startsWith('/settings')}
        <div class="sub-list">
          <Item on:click={goto('/settings/gauges')} activated={$location.pathname === '/settings/gauges'}>
            <Text>Gauges</Text>
          </Item>
          <Item on:click={goto('/settings/togglers')} activated={$location.pathname === '/settings/togglers'}>
            <Text>Togglers</Text>
          </Item>
          <Item on:click={goto('/settings/categories')} activated={$location.pathname === '/settings/categories'}>
            <Text>Categories</Text>
          </Item>
          <Item on:click={goto('/settings/charts')} activated={$location.pathname === '/settings/charts'}>
            <Text>Charts</Text>
          </Item>
          <Item on:click={goto('/settings/appearance')} activated={$location.pathname === '/settings/appearance'}>
            <Text>Appearance</Text>
          </Item>
        </div>
      {/if}
    </List>
  </Content>
</Drawer>

<style lang="scss">
  .sub-list {
    margin-left: 25px;
  }
</style>
