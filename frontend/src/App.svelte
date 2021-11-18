<script lang="ts">
  import CurrentlyPage from 'pages/CurrentlyPage.svelte'
  import LogsPage from 'pages/LogsPage.svelte'
  import urqlClient from 'utils/urql'
  import { setClient } from '@urql/svelte'
  import { Router, Route } from 'svelte-navigator'
  import NavigationMenu from 'components/NavigationMenu.svelte'
  import { Theme } from 'carbon-components-svelte'
  import type { CarbonTheme } from 'carbon-components-svelte/types/Theme/Theme.svelte'
  import SettingsGaugesPage from 'pages/SettingsGaugesPage.svelte'
  import SettingsCategoriesPage from 'pages/SettingsCategoriesPage.svelte'
  import SettingsCategoriesEditPage from 'pages/SettingsCategoriesEditPage.svelte'
  import SettingsGaugesEditPage from 'pages/SettingsGaugesEditPage.svelte'
  import Settings from 'pages/Settings.svelte'

  // setup the urql client
  setClient(urqlClient)

  let theme: CarbonTheme = 'g10'
</script>

<Theme bind:theme persist persistKey="__carbon-theme">
  <Router primary={false}>
    <div class="container">
      <NavigationMenu />
      <main>
        <Route path="/">
          <CurrentlyPage />
        </Route>
        <Route path="/logs">
          <LogsPage />
        </Route>
        <Route path="/charts">
          <span>to come</span>
        </Route>
        <Route path="/settings/*">
          <Route path="/">
            <Settings />
          </Route>
          <Route path="gauges">
            <SettingsGaugesPage />
          </Route>
          <Route path="gauges/edit">
            <SettingsGaugesEditPage />
          </Route>
          <Route path="categories">
            <SettingsCategoriesPage />
          </Route>
          <Route path="categories/edit">
            <SettingsCategoriesEditPage />
          </Route>
          <Route path="appearance">
            <Theme bind:theme render="select" />
          </Route>
        </Route>
      </main>
    </div>
  </Router>
</Theme>

<style lang="scss">
  .container {
    font-family: 'Roboto', sans-serif;
    width: 100vw;
    height: 100vh;
    display: flex;
  }

  main {
    flex-grow: 1;
    padding: 80px;
    height: 100vh;
    overflow-y: auto;
  }
</style>
