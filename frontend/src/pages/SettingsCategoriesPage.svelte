<script lang="ts">
  import { operationStore, query } from '@urql/svelte'
  import { Button } from 'carbon-components-svelte'
  import CategoryRankSwitcher from 'components/CategoryRankSwitcher.svelte'
  import Title from 'components/Title.svelte'
  import { GetCategoriesDocument } from 'generated/operations'
  import type { GetCategoriesQuery, GetCategoriesQueryVariables } from 'generated/queries'
  import { useNavigate } from 'svelte-navigator'

  const navigate = useNavigate()

  const categories = operationStore<GetCategoriesQuery, GetCategoriesQueryVariables>(GetCategoriesDocument)
  query(categories)
</script>
<Title>Categories</Title>

<Button on:click={() => navigate('edit')}>Add Category</Button>
{#if $categories.fetching}
  <span>loading...</span>
{:else if $categories.error}
  <span>{$categories.error.message}</span>
{:else}
  <div class="categories-list">
    <CategoryRankSwitcher categories={$categories.data.categories} />
  </div>
{/if}

<style lang="scss">
  .categories-list {
    margin-top: 8px;
    display: flex;
    flex-direction: column;
    row-gap: 4px;
  }
</style>
