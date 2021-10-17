<script lang="ts">
  export let title: string
  export let area: string
  export let subtitle = ''
</script>

<div class="container" style="grid-area: {area}">
  <div class="title-bar">
    <span class="title">{title}</span>
    <span class="subtitle">{subtitle}</span>
    <span class="interactive-button">
      <slot name="interactiveButton" />
    </span>
  </div>
  <slot />
</div>

<style lang="scss">
  .container {
    display: flex;
    flex-direction: column;
    background: #ffffff;
    overflow: hidden;
  }

  .title-bar {
    height: 30px;
    padding: 10px;
    font-size: 12px;
    display: flex;
    align-items: center;
    justify-content: flex-start;
    box-sizing: border-box;
    border-bottom: 1px solid #bdbdbd;
    position: relative;

    .title {
      text-transform: uppercase;
      margin-right: 3px;
    }

    .interactive-button {
      position: absolute;
      right: 10px;
      display: flex;
      align-items: center;
    }
  }
</style>
