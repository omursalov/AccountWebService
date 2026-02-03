import { defineStore } from 'pinia';

const url = "https://localhost:7247";

export const useAccountStore = defineStore('accountStore', {
  state: () => ({
    accounts: [] as AccountDto[]
  }),
  actions: {
    async getAccounts() {
      const res = await fetch(`${url}/Account/Get`);
      const data = await res.json();
      this.accounts = data;
    },
    async addAccount() {
      this.accounts.push({
        id: "941f5bee-7f69-4e83-b891-699d6a164586",
        labels: "sdf; sdf; sdffsd",
        type: 0,
        login: "test",
        password: "sdfsfdfds"
      });
    }
  }
})

interface AccountDto {
  id: string
  labels: string
  type: number
  login: string,
  password: string
}
