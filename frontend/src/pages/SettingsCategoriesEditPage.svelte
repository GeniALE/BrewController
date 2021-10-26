<script lang="ts">
  import { mutation } from '@urql/svelte'
  import CategoriesEditForm from 'forms/CategoriesEditForm.svelte'
  import { AddNewCategoryDocument } from 'generated/operations'
  import type { AddNewCategoryMutation, AddNewCategoryMutationVariables } from 'generated/queries'
  import { useLocation } from 'svelte-navigator'
  import parseQuery from 'utils/parseQuery'

  const location = useLocation()

  // const categories = operationStore<GetCategoriesQuery, GetCategoriesQueryVariables>(GetCategoriesDocument)
  // query(categories)

  $: categoryId = parseQuery($location.search)['id']
  $: isEditing = typeof categoryId === 'string'

  const addCategory = mutation<AddNewCategoryMutation, AddNewCategoryMutationVariables>({
    query: AddNewCategoryDocument,
  })
</script>

{#if isEditing}
  <CategoriesEditForm {categoryId} />
{/if}
