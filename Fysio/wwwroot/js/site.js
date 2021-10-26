// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// const Vue = window.vue;
// Write your JavaScript code.
const app = new Vue({
    el: "#app",
    data: {
        visible: false,
        curModalId: null,
    },
    created() {
        console.log("Vue running");
    },
});
