import axios from "axios";

const instance = axios.create({
  baseURL: import.meta.env.VITE_API_BASE_URL || "http://localhost:5000", // your ASP.NET Web API base URL
  headers: {
    "Content-Type": "application/json"
  }
});

export default instance;