import { useEffect, useState } from "react";

export default function UsersPage() {
  const [users, setUsers] = useState([]);

  useEffect(() => {
    fetch("http://localhost:5231/api/Users")
      .then(res => res.json())
      .then(data => setUsers(data))
      .catch(err => console.error("Erro ao buscar usuários:", err));
  }, []);

  return (
    <div className="p-4">
      <h1 className="text-2xl font-bold mb-4">Usuários</h1>
      <ul className="space-y-2">
        {users.map(user => (
          <li key={user.id} className="p-3 bg-gray-100 rounded-md shadow-sm">
            <p><strong>Nome:</strong> {user.name}</p>
            <p><strong>Email:</strong> {user.email}</p>
          </li>
        ))}
      </ul>
    </div>
  );
}
