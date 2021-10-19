<script lang="ts">
  import Dialog from '@smui/dialog'
  import { activeModal } from 'stores/activeModal'

  const closeHandler = () => {
    activeModal.set(undefined)
  }
</script>

<Dialog open={true} on:MDCDialog:closed={closeHandler}>
  <slot />
</Dialog>
