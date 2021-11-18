<script lang="ts">
  import { ClickableTile } from 'carbon-components-svelte'

  export let href: string
</script>

<ClickableTile style="height: 100%; border: 1px solid var(--cds-ui-background)" {href}>
  <div class="content">
    <slot name="title" />
    <div class="action">
      <slot name="action" />
    </div>
  </div>
</ClickableTile>

<style lang="scss">
  .content {
    width: 100%;
    height: 100%;
    position: relative;
  }

  .action {
    position: absolute;
    bottom: 0;
    right: 0;
  }
</style>
