<script lang="ts">
  import { operationStore, query } from '@urql/svelte'
  import { Button } from 'carbon-components-svelte'
  import { GetCategoriesDocument } from 'generated/operations'
  import type { GetCategoriesQuery, GetCategoriesQueryVariables } from 'generated/queries'
  import { useNavigate } from 'svelte-navigator'

  const navigate = useNavigate()

  const categories = operationStore<GetCategoriesQuery, GetCategoriesQueryVariables>(GetCategoriesDocument)

  query(categories)
</script>

<h1>Categories</h1>
<Button on:click={() => navigate('edit')}>Add Category</Button>
{#if $categories.fetching}
  <span>loading...</span>
{:else if $categories.error}
  <span>{$categories.error.message}</span>
{:else}
  {#each $categories.data.categories as category}
    <div on:click={() => navigate(`edit?id=${category.id}`)}>{category.name}</div>
  {/each}
{/if}
