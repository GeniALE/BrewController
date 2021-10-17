<script lang="ts">
  import Box from 'components/Box.svelte'
  import ScrollContainer from 'components/ScrollContainer.svelte'
  import TextualButton from 'components/TextualButton.svelte'

  const gotoCategoriesConfiguration = () => {
    console.log('hello')
  }
</script>

<Box title="Currently" area="currently">
  <ScrollContainer>
    <div class="text-container">
      <TextualButton on:click={gotoCategoriesConfiguration}>
        There are no categories set, click here to add some
      </TextualButton>
    </div>
  </ScrollContainer>
</Box>

<style lang="scss">
  .text-container {
    display: flex;
    justify-content: center;
    padding: 15px;
  }
</style>
