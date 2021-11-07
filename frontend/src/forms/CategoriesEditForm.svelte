<script lang="ts">
  import { mutation, operationStore, query } from '@urql/svelte'
  import { Button, ButtonSet, Form, FormGroup, TextInput, TextInputSkeleton } from 'carbon-components-svelte'
  import Title from 'components/Title.svelte'
  import { AddNewCategoryDocument, GetCategoriesDocument, GetCategoryByIdDocument, UpdateCategoryDocument } from 'generated/operations'
  import type { AddNewCategoryMutation, AddNewCategoryMutationVariables, GetCategoriesQuery, GetCategoriesQueryVariables, GetCategoryByIdQuery, GetCategoryByIdQueryVariables, UpdateCategoryMutation, UpdateCategoryMutationVariables } from 'generated/queries'
  import type { AddCategoryInput, UpdateCategoryInput } from 'generated/schema'
  import { Delete20 } from 'carbon-icons-svelte'
  import { useNavigate } from 'svelte-navigator'
  import { isNullOrEmpty } from 'utils/isNullOrEmpty'
import ColorPickerInput from 'components/ColorPickerInput.svelte'

  export let categoryId: string | undefined
  const isEditing = typeof categoryId !== 'undefined'
  let name: string
  let color: string
  let done = false

  const navigate = useNavigate()

  const currentCategory = operationStore<GetCategoryByIdQuery, GetCategoryByIdQueryVariables>(GetCategoryByIdDocument, { id: categoryId }, { pause: !isEditing })
  const categories = operationStore<GetCategoriesQuery, GetCategoriesQueryVariables>(GetCategoriesDocument)

  const addCategory = mutation<AddNewCategoryMutation, AddNewCategoryMutationVariables>({
    query: AddNewCategoryDocument,
  })

  const updateCategory = mutation<UpdateCategoryMutation, UpdateCategoryMutationVariables>({
    query: UpdateCategoryDocument,
  })

  const submit = async () => {
    try {
      if (isEditing) {
        const updatedCategory: UpdateCategoryInput = {
          id: categoryId,
          name,
          color,
        }

        await updateCategory({
          updatedCategory,
        })
      } else {
        const newCategory: AddCategoryInput = {
          name,
          color,
        }

        const ranking = $categories.data.categories.length === 0 ? {} : {
          previousId: $categories.data.categories[$categories.data.categories.length - 1].id,
        }

        await addCategory({
          newCategory,
          ranking,
        })
      }

      navigate('/settings/categories')
    } catch (error) {
      alert(error)
    }
  }

  $: if (!$currentCategory.fetching && $currentCategory.data && !done && isEditing) {
    name = $currentCategory.data.category.name
    color = $currentCategory.data.category.color
    done = true
  }

  query(currentCategory)
  query(categories)
</script>

<Title>{isEditing ? 'Edit' : 'Add'} Category <span class="title-name">{name}</span></Title>

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
      <ColorPickerInput bind:color={color} />
    {/if}
  </FormGroup>
  <div class="submit-buttons">
    <ButtonSet>
      <Button kind="secondary" on:click={() => navigate('/settings/categories')}>Cancel</Button>
      <Button type="submit" disabled={[name, color].some(isNullOrEmpty)}>Submit</Button>
    </ButtonSet>
    <Button kind="danger" iconDescription="Delete category" icon={Delete20} />
  </div>
</Form>

<style lang="scss">
  .submit-buttons {
    display: flex;
    justify-content: space-between;
  }
</style>
