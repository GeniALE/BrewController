<script lang="ts">
  import Box from 'components/Box.svelte'

  const openConfiguration = () => {
    console.log('hello')
  }
</script>

<Box title="Actions Panel" area="side">
  <button on:click={openConfiguration}>open configuration</button>
</Box>
