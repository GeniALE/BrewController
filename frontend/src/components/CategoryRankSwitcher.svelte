<script lang="ts">
  import { mutation } from '@urql/svelte'
  import { UpdateCategoryDocument } from 'generated/operations'
  import type { GetCategoriesQuery, UpdateCategoryMutation, UpdateCategoryMutationVariables } from 'generated/queries'
  import Sortable from 'sortablejs'
  import { onMount } from 'svelte'
  import { useNavigate } from 'svelte-navigator'
  import { fade } from 'svelte/transition'
  import { productive } from 'utils/easings'

  export let categories: GetCategoriesQuery['categories']
  let switcherElement: HTMLDivElement

  const navigate = useNavigate()

  const updateCategory = mutation<UpdateCategoryMutation, UpdateCategoryMutationVariables>({
    query: UpdateCategoryDocument,
  })

  onMount(() => {
    Sortable.create(switcherElement, {
      animation: 200,
      handle: '.handle',
      onEnd: async (event) => {
        const targetId = event.item.getAttribute('data-id')
        const previousId = event.newIndex !== 0 ? event.to.children[event.newIndex - 1].getAttribute('data-id') : undefined
        const nextId = event.newIndex !== event.to.childElementCount - 1 ? event.to.children[event.newIndex + 1].getAttribute('data-id') : undefined

        await updateCategory({
          updatedCategory: {
            id: targetId,
          },
          ranking: {
            previousId,
            nextId,
          },
        })
      },
    })
  })
</script>

<div class="category-rank-switcher" bind:this={switcherElement}>
  {#each categories as category (category.id)}
    <div class="category-rank-tile" data-id={category.id} in:fade={{ easing: productive }} on:click={() => navigate(`edit?id=${category.id}`)}>
      <span class="handle" />
      <span class="category-name">{category.name}</span>
    </div>
  {/each}
</div>

<style lang="scss">
  .category-rank-switcher {
    display: flex;
    flex-direction: column;
    row-gap: 8px;
  }

  .category-rank-tile {
    display: flex;
    column-gap: 1rem;
    align-items: center;
    min-width: 8rem;
    min-height: 4rem;
    padding: var(--cds-spacing-05, 1rem);
    background-color: var(--cds-ui-01, #f4f4f4);
    outline: 2px solid transparent;
    outline-offset: -2px;
  }

  .handle {
    display: inline-block;
    width: 16px;
    height: 24px;
    cursor: move;

    &, &::before, &::after {
      background-image: radial-gradient(var(--cds-ui-05) 40%, transparent 40%);
      background-size: 4px 4px;
      background-position: 0 100%;
      background-repeat: repeat-x;
    }

    &::before, &::after {
      content: '';
      display: block;
      width: 100%;
      height: 33%;
    }
  }
</style>
