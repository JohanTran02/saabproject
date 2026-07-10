export default {
    input: 'http://localhost:8080/swagger/SAABprojectAPI/swagger.json',
    output: {
        path: 'client',
        postProcess: ['eslint', 'prettier']
    },
    plugins: [
        {
            enums: 'javascript',
            name: '@hey-api/typescript',
        },
        '@tanstack/react-query',
        'valibot',
        '@hey-api/client-fetch'
    ],
};