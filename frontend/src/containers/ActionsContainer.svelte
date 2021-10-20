<script lang="ts">
  import Box from 'components/Box.svelte'
  import { activeModal } from 'stores/activeModal'
import { Link } from 'svelte-navigator'

  const openConfiguration = () => {
    activeModal.set('configuration')
  }
</script>

<Box title="Actions Panel" area="side">
  <Link to="configuration">hello</Link>
  <button on:click={openConfiguration}>open configuration</button>
</Box>
