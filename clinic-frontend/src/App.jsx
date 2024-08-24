import { Header } from "./components/abstract/Header";
import { AppRouter } from "./components/util/AppRouter";
import { BrowserRouter } from "react-router-dom";
import { Footer } from "./components/abstract/Footer";

const App = () => {
  return (
    <BrowserRouter>
      <Header />
      <AppRouter />
      <Footer />
    </BrowserRouter>
  );
};

export default App;
