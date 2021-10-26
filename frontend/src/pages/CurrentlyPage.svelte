<script lang="ts">
  import TextualButton from 'components/TextualButton.svelte'

  const gotoCategoriesConfiguration = () => {
    console.log('hello')
  }
</script>

<div class="text-container">
  <TextualButton on:click={gotoCategoriesConfiguration}>
    There are no categories set, click here to add some
  </TextualButton>
</div>

<style lang="scss">
  .text-container {
    display: flex;
    justify-content: center;
    padding: 15px;
  }
</style>
