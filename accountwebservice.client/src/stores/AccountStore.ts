import { defineStore } from 'pinia';

export const useAccountStore = defineStore('accountStore', {
  state: () => ({
    accounts: [
      {
        id: "941f5bee-7f69-4e83-b891-699d6a164586",
        labels: "sdf; sdf; sdffsd",
        type: 0,
        login: "test",
        password: "sdfsfdfds"
      },
      {
        id: "941f5bee-7f69-4e83-b891-699d6a164586",
        labels: "sdf; sdf; sdffsd",
        type: 1,
        login: "test",
        password: "sdfsfdfds"
      },
      {
        id: "941f5bee-7f69-4e83-b891-699d6a164586",
        labels: "sdf; sdf; sdffsd",
        type: 1,
        login: "test",
        password: "sdfsfdfds"
      }
    ]
  })
})
