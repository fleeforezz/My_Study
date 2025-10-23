import axios from "axios";
import { useEffect, useState } from "react";

function Users() {
    const [users, setUsers] = useState([]);

    useEffect(() => {
        const fetchUsers = async () => {
            try {
                const response = await axios.get("/User");
                console.log("API response:", response.data);
                setUsers(response.data);
            } catch (error) {
                console.error("Error fetching users: ", error);
            }
        };

        fetchUsers();
    }, []);

    return (
        <div>
            <h1 style={{ color: "black" }}>Users</h1>
            <ul>
                {users.map((user) => (
                    <li key={user.id}>
                        {user.Name} ({user.Email})
                    </li>
                ))}
            </ul>
        </div>
    )
}

export default Users;