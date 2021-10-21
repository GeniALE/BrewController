<script>
  import CurrentlyPage from 'pages/CurrentlyPage.svelte'
  import LogsPage from 'pages/LogsPage.svelte'
  import urqlClient from 'utils/urql'
  import { setClient } from '@urql/svelte'
  import ConfigurationModal from 'modals/configuration/ConfigurationModal.svelte'
  import { Router, Route } from 'svelte-navigator'
  import NavigationMenu from 'components/NavigationMenu.svelte'

  // setup the urql client
  setClient(urqlClient)
</script>

<Router>
  <div class="container">
    <NavigationMenu />
    <main>
      <CurrentlyPage />
        <LogsPage />
      <Route path="/charts" primary={false}>
        <span>to come</span>
      </Route>
      <Route path="settings/*">
        <ConfigurationModal />
      </Route>
    </main>
  </div>
</Router>

<style lang="scss">
  .container {
    font-family: 'Roboto', sans-serif;
    width: 100vw;
    height: 100vh;
    display: flex;
  }

  main {
    flex-grow: 1;
  }
</style>
