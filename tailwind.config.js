/** @type {import('tailwindcss').Config} */
module.exports = {
    mode: 'jit',
    purge: {
        enabled: false,
        content: [
            './**/*.razor',
            './**/*.cshtml'
        ]
    },
}