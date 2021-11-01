<script context="module" lang="ts">
  export interface RankItem {
    id: string
    value: string
  }
</script>

<script lang="ts">
  import { Tile } from 'carbon-components-svelte'
  import { onMount } from 'svelte'
  import Sortable from 'sortablejs'

  export let items: RankItem[]
  export let targetId: string = undefined
  let inputElement: HTMLDivElement

  onMount(() => {
    Sortable.create(inputElement, {
      animation: 200,
      filter: '.stick',
    })
  })
</script>

<div class="rank-input" bind:this={inputElement}>
  {#each items as item}
    <Tile class={item.id === targetId ? 'target' : 'stick'}>{item.value}</Tile>
  {/each}
</div>

<style lang="scss">
  .rank-input {
    display: flex;
    flex-direction: column;
  }

  ::global(.target) {
    background-color: green;
    cursor: pointer;
  }
</style>

