import axios from "axios";

export default axios.create({
  baseURL: "http://localhost:5000/api", // your ASP.NET Web API base URL
});