<script lang="ts">
  import { ClickableTile } from 'carbon-components-svelte'

  export let href: string
</script>

<div class="container">
  <ClickableTile style="height: 100%;" {href}>
    <div class="content">
      <slot name="title" />
      <div class="action">
        <slot name="action" />
      </div>
    </div>
  </ClickableTile>
</div>

<style lang="scss">
  .container {
    width: 100%;
    height: 100%;
    border-right: 1px solid transparent;
    border-bottom: 1px solid transparent;
  }

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
