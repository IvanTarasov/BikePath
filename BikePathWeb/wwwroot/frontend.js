import Vue from 'https://cdn.jsdelivr.net/npm/vue@2.6.11/dist/vue.esm.browser.js'

new Vue({
    el: "#app",
    data() {
        return {
            form: {
                title: '',
                value: ''
            },
            distance: 0,

            routes: []
        }
    },
    computed: {
    	canCreate(){
    		return this.title && this.value
    	}
    },
    methods: {
        createRoute() {
        	const{...route} = this.form

            this.routes.push({ ...route, id: Date.now() });

        	this.form.title = this.form.value = ''
        },

        useRoute(id){
        	this.distance += parseInt(this.routes.find(r => r.id === id).value)
        },

        deleteRoute(id){
        	this.routes = this.routes.filter(r => r.id !== id)
        }
    },
    async mounted() {
        routes = await request("/api/routes")
        console.log(request)
    }
})

async function request(url, method = "GET", data = null){
    try {
        const headers = {}
        let body

        if (data) {
            headers["Content-Type"] = "aplication/json"
            body = JSON.stringify(data)
        }

        const response = await fetch(url, {
            method,
            headers,
            body
        })

        alert(response)
        return response.json()
	} catch (e) {
		console.warn('error: ', e.message)
	}
}