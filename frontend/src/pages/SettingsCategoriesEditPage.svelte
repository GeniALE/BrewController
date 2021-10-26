<script lang="ts">
  import CategoriesEditForm from 'forms/CategoriesEditForm.svelte'
  import { useLocation } from 'svelte-navigator'
  import parseQuery from 'utils/parseQuery'

  const location = useLocation()

  $: categoryId = parseQuery($location.search)['id']
</script>

<CategoriesEditForm {categoryId} />
