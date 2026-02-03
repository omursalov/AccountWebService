<template>
  <div class="weather-component">
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
          <tr v-for="forecast in post">
            <td><input type="text" v-model="forecast.labels" /></td>
            <td>{{ forecast.type }}</td>
            <td>{{ forecast.login }}</td>
            <td>{{ forecast.password }}</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>
