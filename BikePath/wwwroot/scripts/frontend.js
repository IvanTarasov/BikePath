let app = new Vue({
    el: "#app",
    data() {
        return {
            routeForm: {
                title: '',
                length: 0,
            },

            userLogin: {
                email: '',
                password: ''
            },

            userId: 0,
            name: '',
            distance: 0.0,
            routes: [],

            loadData: false
        }
    },
    created: function () {
        this.getUser()
        this.getRoutes()
    },

    methods: {
        showCreateRouteModal() {
            $("#createRouteModal").modal("show")
        },

        getUser() {
            this.loadData = true
            let vm = this

            vm.userLogin.email = 'ivan.tarasov12345@gmail.com'
            vm.userLogin.password = 'ivan12345'

            let user = {
                email: vm.userLogin.email,
                password: vm.userLogin.password
            }

            $.ajax({ url: "/user", data: user, method: "GET" })
                .done(
                    function (data) {
                        vm.userId = data.id
                        vm.name = data.name
                        vm.distance = data.distance

                        vm.loadData = false
                        toastr.success("User received successfully")
                    })
                .fail(
                    function () {
                        toastr.error("User received error")
                    })
        },

        getRoutes() {
            this.loadData = true
            let vm = this

            $.ajax({ url: "/main", method: "GET" })
                .done(
                    function (data) {
                        vm.routes = data.reverse()

                        vm.loadData = false
                        toastr.success("Routes received successfully")
                    })
                .fail(
                    function () {
                        toastr.error("Routes received error")
                    })
        },

        createRoute() {
            let vm = this

            let route = {
                userId: vm.userId,
                title: vm.routeForm.title,
                length: vm.routeForm.length
            }

            $.ajax({ url: "/main", data: route, method: "POST" })
                .done(
                    function (newRoute) {
                        vm.routes.splice(0, 0, newRoute);
                        toastr.success("Route created!");
                    })
                .fail(
                    function () {
                        toastr.error("Route create error!")
                    })
                .always(
                    function () {
                        vm.routeForm.title = ''
                        vm.routeForm.length = 0.0
                    })
        },

        useRoute(id) {
            let vm = this

            let routeLength = vm.routes.find(r => r.id === id).length

            $.ajax({ url: "/user", data: { userId: vm.userId, length: routeLength }, method: "PUT" })
                .done(
                    function (newDistance) {
                        vm.distance = newDistance
                        toastr.success("Distance success update")
                    })
                .fail(
                    function () {
                        toastr.error("Distance update error")
                    })
        },

        deleteRoute(id) {
            let vm = this

            const route = vm.routes.find(r => r.id === id)

            $.ajax({ url: "/main", data: route, method: "DELETE" })
                .done(
                    function () {
                        vm.routes = vm.routes.filter(r => r.id !== id)
                        toastr.success("Route success cleared")
                    })
                .fail(
                    function () {
                        toastr.error("Route cleared error")
                    })
        },
    },
})