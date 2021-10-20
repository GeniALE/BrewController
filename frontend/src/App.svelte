<script>
  import ActionsContainer from 'containers/ActionsContainer.svelte'
  import CurrentlyContainer from 'containers/CurrentlyContainer.svelte'
  import LogsContainer from 'containers/LogsContainer.svelte'
  import urqlClient from 'utils/urql'
  import { setClient } from '@urql/svelte'
  import ConfigurationModal from 'modals/configuration/ConfigurationModal.svelte'
  import ControlPanelModal from 'modals/ControlPanelModal.svelte'
  import { Router, Route } from 'svelte-navigator'

  const modals = {
    configuration: ConfigurationModal,
    controlPanel: ControlPanelModal,
  }

  // setup the urql client
  setClient(urqlClient)
</script>

<Router>
  <Route path="/">
    <main>
      <ActionsContainer />
      <CurrentlyContainer />
      <LogsContainer />
    </main>
  </Route>
  <Route path="configuration/*">
    <ConfigurationModal />
  </Route>
</Router>

<style lang="scss">
  main {
    font-family: 'Roboto', sans-serif;
    background: #bdbdbd;
    width: 100vw;
    height: 100vh;
    display: grid;
    column-gap: 1px;
    row-gap: 1px;
    grid-template-columns: 4fr 3.5fr 40%;
    grid-template-rows: 3.5fr 1.5fr;
    grid-template-areas:
      'logs currently charts'
      'side currently charts';
  }
</style>
