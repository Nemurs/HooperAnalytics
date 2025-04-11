/// <reference types="vite/client" />
import { defineConfig } from "vitest/config"
import react from "@vitejs/plugin-react"
import { loadEnv } from "vite";
const env = loadEnv('', "./");

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  server: {
    port:3000,
    proxy: {
      '/api': {
        target: env.VITE_API_BASE_URL,
        changeOrigin: true,
        secure: false
      }
    }
  },
  test: {
    globals: true,
    environment: "jsdom",
    setupFiles: "src/setupTests",
    mockReset: true,
  },
})
