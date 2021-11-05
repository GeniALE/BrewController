<script lang="ts">
  import GaugesEditForm from 'forms/GaugesEditForm.svelte'
  import { useLocation } from 'svelte-navigator'
  import parseQuery from 'utils/parseQuery'

  const location = useLocation()

  $: gaugeId = parseQuery($location.search)['id']
</script>

<GaugesEditForm {gaugeId} />
