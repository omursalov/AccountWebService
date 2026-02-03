<template>
    <div class="weather-component">
        <h1>Учетные записи <button type="submit" class="btn btn-primary">+</button></h1>
        <p>Для указания нескольких меток для одной пары логин/пароль используйте разделитель</p>

        <div v-if="post" class="content">
            <table>
                <thead>
                    <tr>
                        <th>Метки</th>
                        <th>Тип записи</th>
                        <th>Логин</th>
                        <th>Пароль</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="forecast in post" :key="forecast.date">
                        <td><input type="text" v-model="forecast.summary" /></td>
                        <td>{{ forecast.temperatureC }}</td>
                        <td>{{ forecast.temperatureF }}</td>
                        <td>{{ forecast.summary }}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script lang="ts">
    import "bootstrap/dist/css/bootstrap.min.css"
    import "bootstrap"
    import { defineComponent } from 'vue';

    type Forecasts = {
        date: string,
        temperatureC: string,
        temperatureF: string,
        summary: string
    }[];

    interface Data {
        loading: boolean,
        post: null | Forecasts
    }

    export default defineComponent({
        data(): Data {
            return {
                loading: false,
                post: null
            };
        },
        async created() {
            // fetch the data when the view is created and the data is
            // already being observed
            await this.fetchData();
        },
        watch: {
            // call again the method if the route changes
            '$route': 'fetchData'
        },
        methods: {
            async fetchData() {
                this.post = null;
                this.loading = true;

                var response = await fetch('account');
                if (response.ok) {
                    this.post = await response.json();
                    this.loading = false;
                }
            }
        },
    });
</script>

<style scoped>
th {
    font-weight: bold;
}

th, td {
    padding-left: .5rem;
    padding-right: .5rem;
}

.weather-component {
    text-align: center;
}

table {
    margin-left: auto;
    margin-right: auto;
}
</style>
