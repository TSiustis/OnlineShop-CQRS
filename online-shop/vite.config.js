// vite.config.js
import {defineConfig} from 'vite'

// https://vitejs.dev/config/
export default defineConfig(() => ({
  esbuild: {
    loader: "jsx", // OR "jsx"
    include: [
      "src/**/*.jsx",
      "node_modules/**/*.jsx",
    ],
  },
}));