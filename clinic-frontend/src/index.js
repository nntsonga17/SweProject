import ReactDOM from "react-dom/client";
import App from "./App";

import { QueryClientProvider } from "react-query";
import { ToastContainer } from "react-toastify";
import { queryClient } from "./lib/react-query";

import "./styles/index.scss";

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <QueryClientProvider client={queryClient}>
    <ToastContainer
      position="top-right"
      autoClose={3000}
      closeOnClick
      hideProgressBar={true}
      theme="light"
    />
    <App />
  </QueryClientProvider>
);
