import { defineStore } from 'pinia';

const url = "https://localhost:7247";

export const useAccountStore = defineStore('accountStore', {
  state: () => ({
    accounts: [] as AccountDto[]
  }),
  actions: {
    async load() {
      this.getAccounts();
    },
    async getAccounts() {
      const res = await fetch(`${url}/Account/Get`);
      const data: AccountDto[] = await res.json();
      this.accounts = data;
    },
    async addAccount() {
      const newAccount: AccountDto = {
        id: crypto.randomUUID(),
        labels: null,
        type: 'local',
        login: "Значение",
        password: null
      };

      const res = await fetch(`${url}/Account/AddOrUpdate`, {
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
    async updateAccount(id: string) {
      const account = this.accounts.find(x => x.id == id) as AccountDto;

      if (account.type == 'ldap') {
        account.password = null;
      }
      
      const res = await fetch(`${url}/Account/AddOrUpdate`, {
        method: "POST",
        headers: {
          'Accept': 'application/json, text/plain',
          'Content-Type': 'application/json;charset=UTF-8',
          'Access-Control-Allow-Headers': '*'
        },
        body: JSON.stringify(account)
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
  id: string;
  labels: string | null;
  type: string;
  login: string;
  password: string | null;
}
