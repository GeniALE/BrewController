<script lang="ts">
  import { activeModal } from 'stores/activeModal'

  const closeHandler = () => {
    activeModal.set(undefined)
  }
</script>
