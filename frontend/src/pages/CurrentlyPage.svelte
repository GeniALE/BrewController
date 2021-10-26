<script lang="ts">
  import ScrollContainer from 'components/ScrollContainer.svelte'
  import TextualButton from 'components/TextualButton.svelte'

  const gotoCategoriesConfiguration = () => {
    console.log('hello')
  }
</script>

<ScrollContainer>
  <div class="text-container">
    <TextualButton on:click={gotoCategoriesConfiguration}>
      There are no categories set, click here to add some
    </TextualButton>
  </div>
</ScrollContainer>

<style lang="scss">
  .text-container {
    display: flex;
    justify-content: center;
    padding: 15px;
  }
</style>
