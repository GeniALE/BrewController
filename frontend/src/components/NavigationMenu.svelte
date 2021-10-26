<script lang="ts">
  import { SideNav, SideNavItems, SideNavMenu, SideNavMenuItem as Item, SideNavLink } from 'carbon-components-svelte'
  import { useLocation, useNavigate } from 'svelte-navigator'

  const location = useLocation()
  const navigate = useNavigate()
</script>

<SideNav isOpen>
  <SideNavItems>
    <SideNavLink on:click={() => navigate('/')} isSelected={$location.pathname === '/'} text="Overview" />
    <SideNavLink on:click={() => navigate('/logs')} isSelected={$location.pathname === '/logs'} text="Logs" />
    <SideNavLink on:click={() => navigate('/charts')} isSelected={$location.pathname === '/charts'} text="Charts" />
    <SideNavMenu expanded={$location.pathname.startsWith('/settings')} text="Settings">
      <Item on:click={() => navigate('/settings/gauges')} isSelected={$location.pathname === '/settings/gauges'}>
        Gauges
      </Item>
      <Item on:click={() => navigate('/settings/togglers')} isSelected={$location.pathname === '/settings/togglers'}>
        Togglers
      </Item>
      <Item on:click={() => navigate('/settings/categories')} isSelected={$location.pathname === '/settings/categories'}>
        Categories
      </Item>
      <Item on:click={() => navigate('/settings/charts')} isSelected={$location.pathname === '/settings/charts'}>
        Charts
      </Item>
      <Item on:click={() => navigate('/settings/appearance')} isSelected={$location.pathname === '/settings/appearance'}>
        Appearance
      </Item>
    </SideNavMenu>
  </SideNavItems>
</SideNav>

<style lang="scss">
  :global(nav.bx--side-nav) {
    position: static;
  }
</style>
