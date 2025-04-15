import React from "react"
import { createRoot } from "react-dom/client"
import { BrowserRouter, Routes, Route } from "react-router";
import { Provider } from "react-redux"
import App from "./App"
import {Test} from "./features/test/Test"
import { store } from "./app/store"
import "./index.css"

const container = document.getElementById("root")

if (container) {
  const root = createRoot(container)

  root.render(
    <React.StrictMode>
      <BrowserRouter>
        <Routes>
          <Route path="/test" element={
            <Provider store={store}>
              <Test />
            </Provider>
          } />
          <Route path="/" element={
            <Provider store={store}>
              <App />
            </Provider>
          } />
        </Routes>
      </BrowserRouter>
    </React.StrictMode>,
  )
} else {
  throw new Error(
    "Root element with ID 'root' was not found in the document. Ensure there is a corresponding HTML element with the ID 'root' in your HTML file.",
  )
}
