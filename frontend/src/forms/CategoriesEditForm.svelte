<script lang="ts">
  import { mutation, operationStore, query } from '@urql/svelte'
  import { Button, ButtonSet, Form, FormGroup, TextInput, TextInputSkeleton } from 'carbon-components-svelte'
  import Title from 'components/Title.svelte'
  import { GetCategoryByIdDocument, UpdateCategoryDocument } from 'generated/operations'
  import type { GetCategoryByIdQuery, GetCategoryByIdQueryVariables, UpdateCategoryMutation, UpdateCategoryMutationVariables } from 'generated/queries'
  import type { UpdateCategoryInput } from 'generated/schema'
  import { useNavigate } from 'svelte-navigator'
  import { isNullOrEmpty } from 'utils/isNullOrEmpty'

  export let categoryId: string
  let name: string
  let color: string
  let done = false

  const navigate = useNavigate()

  const currentCategory = operationStore<GetCategoryByIdQuery, GetCategoryByIdQueryVariables>(GetCategoryByIdDocument, { id: categoryId })

  const updateCategory = mutation<UpdateCategoryMutation, UpdateCategoryMutationVariables>({
    query: UpdateCategoryDocument,
  })

  const submit = async () => {
    const updatedCategory: UpdateCategoryInput = {
      id: categoryId,
      name,
      color,
    }

    try {
      await updateCategory({
        updatedCategory,
      })

      navigate('/settings/categories')
    } catch (error) {
      alert(error)
    }
  }

  $: if (!$currentCategory.fetching && $currentCategory.data && !done){
    name = $currentCategory.data.category.name
    color = $currentCategory.data.category.color
    done = true
  }

  query(currentCategory)
</script>

<Title>Edit Category <span class="title-name">{name}</span></Title>

<Form on:submit={submit}>
  <FormGroup>
    {#if $currentCategory.fetching}
      <TextInputSkeleton />
    {:else}
      <TextInput size="xl" labelText="Name" bind:value={name} />
    {/if}
  </FormGroup>
  <FormGroup>
    {#if $currentCategory.fetching}
      <TextInputSkeleton />
    {:else}
      <TextInput size="xl" labelText="Color" bind:value={color} />
    {/if}
  </FormGroup>
  <ButtonSet>
    <Button kind="secondary" on:click={() => navigate('/settings/categories')}>Cancel</Button>
    <Button type="submit" disabled={[name, color].some(isNullOrEmpty)}>Submit</Button>
  </ButtonSet>
</Form>
