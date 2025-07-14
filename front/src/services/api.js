const API_URL = 'http://localhost:5240/books'

export const bookService = {
  async getBooks(page, pageSize) {
    const response = await fetch(
      `${API_URL}`
    )
    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`)
    }
    return response.json()
  }
} 