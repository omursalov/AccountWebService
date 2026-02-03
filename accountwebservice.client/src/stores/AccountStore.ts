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
      const newAccount = {
        id: crypto.randomUUID(),
        labels: "Значение",
        type: 0,
        login: "Значение",
        password: ""
      };
      const res = await fetch(`${url}/Account/Add`, {
        method: "POST",
        headers: {
          'Accept': 'application/json, text/plain',
          'Content-Type': 'application/json;charset=UTF-8',
          'Access-Control-Allow-Headers': '*'
        },
        body: JSON.stringify(newAccount)
      });
      this.getAccounts();
    },
    async deleteAccount(id: string) {
      const res = await fetch(`${url}/Account/Delete?id=${id}`, {
        method: "DELETE",
        headers: {
          'Access-Control-Allow-Headers': '*'
        }
      });
      this.getAccounts();
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
