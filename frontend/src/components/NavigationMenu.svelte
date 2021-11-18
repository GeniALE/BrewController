<script lang="ts">
  import { Button } from 'carbon-components-svelte'
  import { ChartLine24, Document24, Settings24, Workspace24 } from 'carbon-icons-svelte'
  import { useLocation, useNavigate } from 'svelte-navigator'

  const location = useLocation()
  const navigate = useNavigate()
</script>

<div class="nav-menu">
  <Button kind="ghost" tooltipPosition="top" icon={Workspace24} on:click={() => navigate('/')} isSelected={$location.pathname === '/'} iconDescription="Overview" />
  <Button kind="ghost" tooltipPosition="top" icon={Document24} on:click={() => navigate('/logs')} isSelected={$location.pathname === '/logs'} iconDescription="Logs" />
  <Button kind="ghost" tooltipPosition="top" icon={ChartLine24} on:click={() => navigate('/charts')} isSelected={$location.pathname === '/charts'} iconDescription="Charts" />
  <Button kind="ghost" tooltipPosition="top" icon={Settings24} on:click={() => navigate('/settings')} isSelected={$location.pathname.startsWith('/settings')} iconDescription="Settings" />
</div>

<style lang="scss">
  .nav-menu {
    position: absolute;
    bottom: 0;
  }
</style>
