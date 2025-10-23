import axiosInstance from "../api/axios";
import { useEffect, useState } from "react";

function Users() {
    const [users, setUsers] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchUsers = async () => {
            try {
                setLoading(true);
                // Add /api prefix here 👇
                const response = await axiosInstance.get("/api/User");
                console.log("API response:", response.data);
                setUsers(response.data);
                setError(null);
            } catch (error) {
                console.error("Error fetching users:", error);
                setError(error.response?.data?.message || error.message || "Failed to fetch users");
            } finally {
                setLoading(false);
            }
        };

        fetchUsers();
    }, []);

    if (loading) return <div>Loading...</div>;
    if (error) return <div style={{ color: "red" }}>Error: {error}</div>;

    return (
        <div>
            <h1 style={{ color: "black" }}>Users</h1>
            {users.length === 0 ? (
                <p>No users found</p>
            ) : (
                <ul>
                    {users.map((user) => (
                        <li key={user.id}>
                            {user.name || user.Name} ({user.email || user.Email})
                        </li>
                    ))}
                </ul>
            )}
        </div>
    );
}

export default Users;