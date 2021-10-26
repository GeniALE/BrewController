<script lang="ts">
  import CategoriesAddForm from 'forms/CategoriesAddForm.svelte'
  import CategoriesEditForm from 'forms/CategoriesEditForm.svelte'
  import { useLocation } from 'svelte-navigator'
  import parseQuery from 'utils/parseQuery'

  const location = useLocation()

  // const categories = operationStore<GetCategoriesQuery, GetCategoriesQueryVariables>(GetCategoriesDocument)
  // query(categories)

  $: categoryId = parseQuery($location.search)['id']
  $: isEditing = typeof categoryId === 'string'
</script>

{#if isEditing}
  <CategoriesEditForm {categoryId} />
{:else}
  <CategoriesAddForm />
{/if}
