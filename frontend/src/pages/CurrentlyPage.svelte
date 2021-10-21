<script lang="ts">
  import ScrollContainer from 'components/ScrollContainer.svelte'
  import TextualButton from 'components/TextualButton.svelte'
  import { Route } from 'svelte-navigator'

  const gotoCategoriesConfiguration = () => {
    console.log('hello')
  }
</script>

<Route path="/" primary={false}>
  <ScrollContainer>
    <div class="text-container">
      <TextualButton on:click={gotoCategoriesConfiguration}>
        There are no categories set, click here to add some
      </TextualButton>
    </div>
  </ScrollContainer>
</Route>

<style lang="scss">
  .text-container {
    display: flex;
    justify-content: center;
    padding: 15px;
  }
</style>
