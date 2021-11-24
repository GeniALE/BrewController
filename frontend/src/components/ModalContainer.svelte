<script lang="ts">
  import { setModalContainer, destroyModal } from 'utils/modal'
</script>

<div class="modal-container" role="presentation" use:setModalContainer>
  <div class="background" on:click={() => $destroyModal?.()} />
</div>

<style lang="scss">
  .modal-container {
    width: 100vw;
    height: 100vh;
    z-index: 9999;
    position: absolute;
    top: 0;
    left: 0;
    align-items: center;
    justify-content: center;
  }

  .background {
    width: 100%;
    height: 100%;
    position: absolute;
    background: var(--cds-overlay-01);
    z-index: -1;
  }
</style>
