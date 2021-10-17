<script lang="ts">
  import type { LogType } from 'generated/schema'

  export let type: LogType
  export let date: string
  export let time: string
  export let message: string
</script>

<div class="log-container">
  <span class="indicator"
    class:update={type === 'UPDATE'}
    class:info={type === 'INFO'}
    class:error={type === 'ERROR'}>A</span>
  <span class="datetime">{date}</span>
  <span class="datetime">{time}</span>
  <span class="message">{message}</span>
</div>

<style lang="scss">
  .log-container {
    display: flex;
    height: 30px;
    background: #ffffff;
    border-bottom: 1px solid #bdbdbd;
    padding: 0 10px;
    font-size: 12px;
    align-items: center;
    white-space: nowrap;

    &:nth-of-type(odd) {
      background: #f2f2f2;
    }
  }

  .indicator {
    margin: 0 10px 0 0;
    display: flex;

    &.update {
      color: #27ae60;
    }

    &.info {
      color: #2f80ed;
    }

    &.error {
      color: #eb5757;
    }
  }

  .datetime {
    color: #828282;
    margin: 0 10px 0 0;
  }

  .message {
    color: #000000;
    overflow: hidden;
    text-overflow: ellipsis;
  }
</style>
