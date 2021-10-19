<script lang="ts">
  import Box from 'components/Box.svelte'
  import { activeModal } from 'stores/activeModal'

  const openConfiguration = () => {
    activeModal.set('configuration')
  }
</script>

<Box title="Actions Panel" area="side">
  <button on:click={openConfiguration}>open configuration</button>
</Box>
