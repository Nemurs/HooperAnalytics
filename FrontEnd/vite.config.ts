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
    cors: {
      preflightContinue:true,
      origin: true
    },
    proxy: {
      '/api': {
        target: env.VITE_API_BASE_URL,
        changeOrigin: true,
        secure: false,
        configure: (proxy, _options) => {
          proxy.on('error', (err, _req, _res) => {
            console.log('proxy error', err);
          });
          proxy.on('proxyReq', (proxyReq, req, _res) => {
            console.log('Sending Request to the Target:', req.method, req.url);
          });
          proxy.on('proxyRes', (proxyRes, req, _res) => {
            console.log('Received Response from the Target:', proxyRes.statusCode, req.url);
          });
        },
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
