<script lang="ts">
  import { Button } from 'carbon-components-svelte'
  import { Reset20 } from 'carbon-icons-svelte'
  import { generateColor, possibleColors } from 'utils/colors'

  export let color: string = generateColor()

  let inputColors = possibleColors.map((possibleColor) => [possibleColor, generateColor(possibleColor)])

  const reloadColors = () => {
    inputColors = possibleColors.map((possibleColor) => [possibleColor, generateColor(possibleColor)])
  }
</script>

<span class="bx--label">Color</span>

<div class="selected-color" style={`background: ${color}`} />

<div class="color-selector">
  {#each inputColors as [inputColorText, inputColor] (inputColorText)}
    <span
      class="color-input-button"
      class:selected={color === inputColor}
      style={`background: ${inputColor}`}
      on:click={() => color = inputColor} />
  {/each}
  <Button iconDescription="Reload colors" icon={Reset20} on:click={reloadColors} />
</div>

<style lang="scss">
  .selected-color {
    height: 80px;
    width: 100%;
    margin-bottom: 8px;
  }

  .color-selector {
    display: flex;
    column-gap: 4px;

    .color-input-button {
      height: 48px;
      flex-grow: 1;
      box-sizing: border-box;

      &.selected {
        border: 2px solid var(--cds-ui-05);
      }
    }
  }
</style>
