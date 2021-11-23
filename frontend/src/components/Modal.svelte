<script lang="ts">
  import { setModalContainer, closeModal } from 'utils/modal'

  const onCloseModal = () => {
    closeModal?.()
  }
</script>

<div class="modal" role="presentation" use:setModalContainer>
  <div class="background" on:click={onCloseModal} />
</div>

<style lang="scss">
  .modal {
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
