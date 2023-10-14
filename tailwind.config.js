/** @type {import('tailwindcss').Config} */
module.exports = {
    content: ["./**/*.{razor,html,cshtml}"],
    theme: {
        extend: {
            fontFamily: {
                'grotesk': ['Familjen Grotesk', 'sans-serif'],
            },
        },
    },
    plugins: [],
}